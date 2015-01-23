__author__ = 'Hooligan'

import requests
import CreateJsonObject as cjo
import postgresql_utility.PostGreSqlUtility as pgs_utility

base_url = 'http://localhost:5000'

if __name__ == "__main__":

    location = pgs_utility.Location(12.0, 25.2, 30.1)
    meta = cjo.create_meta(10, True, location)

    # Temperature, RFID, Light
    temperature = cjo.create_temperature(65.9)
    rfid = cjo.create_rfid('8p94c71b7920x241')
    light = cjo.create_light(180.4)

    sensors = [temperature, rfid, light]
    sensors = cjo.create_sensors(sensors)

    payload = cjo.create_json(meta, sensors)
    r = requests.post(base_url + '/postToDB', data=payload)
    print r.text
