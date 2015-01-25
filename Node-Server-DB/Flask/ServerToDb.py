__author__ = 'Hooligan'
from flask import Flask, request, jsonify
import json
import ConstantStrings as cs
import postgresql_utility.PostGreSqlUtility as pgs_utils

app = Flask(__name__)
util = pgs_utils.Utility('postgres', 'postgres', 'localhost', 'password')

@app.route('/postToDB', methods=['GET', 'POST'])
def post_to_db():
    try:
        json_obj = json.loads(request.form[cs.KEY_JSON_PAYLOAD])
        meta = json_obj[cs.KEY_META]
        lc = meta[cs.KEY_LOCATION]
        loc = pgs_utils.Location(lc[cs.KEY_X_LOC], lc[cs.KEY_Y_LOC], lc[cs.KEY_Z_LOC])
        sensors = json_obj[cs.KEY_SENSORS]
        packet = pgs_utils.Packet(meta[cs.KEY_NODE_ID], loc, meta[cs.KEY_NODE_STATUS])
        trans_id = util.ups_into_table(packet)
        for sensor, value in sensors.iteritems():
            sens_packet = pgs_utils.SensorPacket(trans_id, value[cs.KEY_VALUE])
            if sensor == cs.KEY_TEMPERATURE:
                util.ins_into_temp_table(sens_packet)
            if sensor == cs.KEY_LIGHT:
                util.ins_into_light_table(sens_packet)
            if sensor == cs.KEY_RFID:
                util.ins_into_rfid_table(sens_packet)
        hist_packet = pgs_utils.HistoryPacket(trans_id, meta[cs.KEY_NODE_ID], meta[cs.KEY_NODE_STATUS], meta[cs.KEY_NODE_IP], loc)
        util.ins_into_node_history_table(hist_packet)
        resp = {
            'response': {
                'status': 200
            }
        }
        return jsonify(**resp)
    except Exception, e:
        resp = {
            'response': {
                'status': 500
            },
            'error': {
                'message': e.message
            }
        }
        return jsonify(**resp)


if __name__ == "__main__":
    app.debug = True
    app.run(host='0.0.0.0')