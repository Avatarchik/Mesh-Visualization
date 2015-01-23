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
        #sensors = json_obj[cs.KEY_SENSORS]
        packet = pgs_utils.Packet(meta[cs.KEY_NODE_ID], loc, meta[cs.KEY_NODE_STATUS])
        trans_id = util.ups_into_table(packet)
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
                'message': e
            }
        }
        return jsonify(**resp)


if __name__ == "__main__":
    app.debug = True
    app.run(host='0.0.0.0')