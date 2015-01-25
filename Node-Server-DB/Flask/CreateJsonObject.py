__author__ = 'Hooligan'
import json
import postgresql_utility.PostGreSqlUtility as pgs_utility
import ConstantStrings as cs


def create_meta(node_id, node_status, location, ip_addr):
    _meta = {
        cs.KEY_NODE_ID: node_id,
        cs.KEY_NODE_STATUS: node_status,
        cs.KEY_NODE_IP: ip_addr,
        cs.KEY_LOCATION:
            {
                cs.KEY_X_LOC: location.x_loc,
                cs.KEY_Y_LOC: location.y_loc,
                cs.KEY_Z_LOC: location.z_loc
            }
    }
    return _meta


def create_temperature(value):
    return {
        cs.KEY_TEMPERATURE:
            {
                cs.KEY_VALUE: value
            }
    }


def create_rfid(r_id):
    return {
        cs.KEY_RFID:
            {
                cs.KEY_VALUE: r_id
            }
    }


def create_light(value):
    return {
        cs.KEY_LIGHT:
            {
                cs.KEY_VALUE: value
            }
    }


def create_sensors(sensors):
    source = dict()
    [source.update(dic) for dic in sensors]
    return source


def create_json(meta, sensors):
    data = {
        cs.KEY_META: meta,
        cs.KEY_SENSORS: sensors
    }
    #data = {
    #    'meta': {'node_status': 1, 'node_id': 1, 'location': {'x': 10, 'y': 24.3, 'z': 55.3}},
    #    'sensors': {'temperature': {'value': 67}, 'light': {'value': 188.3}, 'rfid': '12hks73idkvu45'}
    #}
    data_json = json.dumps(data)
    payload = {cs.KEY_JSON_PAYLOAD: data_json}
    return payload


if __name__ == "__main__":

    meta = create_meta(10, 1, pgs_utility.Location(23.4, 12.5, 16.9))
    temp = create_temperature(67.3)
    rfid = create_rfid('142b1idjd8274y')
    light = create_light(180.3)
    lst_sensors = [temp, rfid, light]
    sensors = create_sensors(lst_sensors)
    json_payload = create_json(meta, sensors)
    print json.dumps(json_payload)