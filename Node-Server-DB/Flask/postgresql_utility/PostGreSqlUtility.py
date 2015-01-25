import psycopg2 as psy


class Utility:

    conn = None
    cur = None

    def __init__(self, db_name, user, host, password):
        try:
            str_conn = "dbname=%s user=%s host=%s password= %s" % (db_name, user, host, password)
            self.conn = psy.connect(str_conn)
            self.cur = self.conn.cursor()
        except Exception, e:
            print e

    # Upsert
    def ups_into_table(self, packet):
        try:
            self.cur.execute(
                "SELECT update_db(%s,%s,(%s,%s,%s));",
                (packet.n_id, packet.node_status,
                 packet.location.x_loc, packet.location.y_loc, packet.location.z_loc)
            )
            trans_id = self.cur.fetchone()[0]
            self.conn.commit()
            return trans_id
        except Exception, e:
            print e
            raise e

    def ins_into_temp_table(self, packet):
        try:
            self.cur.execute(
                "INSERT INTO temperature_sensor_table (transaction_id, value) VALUES (%s, %s);",
                (packet.transaction_id, packet.value)
            )
            self.conn.commit()
        except Exception, e:
            raise e

    def ins_into_rfid_table(self, packet):
        try:
            self.cur.execute(
                "INSERT INTO rfid_sensor_table (transaction_id, value) VALUES (%s, %s);",
                (packet.transaction_id, packet.value)
            )
            self.conn.commit()
        except Exception, e:
            raise e

    def ins_into_light_table(self, packet):
        try:
            self.cur.execute(
                "INSERT INTO light_sensor_table (transaction_id, value) VALUES (%s, %s);",
                (packet.transaction_id, packet.value)
            )
            self.conn.commit()
        except Exception, e:
                raise e

    def ins_into_node_history_table(self, packet):
        try:
            self.cur.execute(
                "INSERT INTO node_history_table (transaction_id, node_id, status, location, ip_address) VALUES (%s, %s, %s, (%s, %s, %s), %s)",
                (packet.transaction_id, packet.node_id, packet.node_status, packet.location.x_loc, packet.location.y_loc, packet.location.z_loc, packet.node_ip)
            )
            self.conn.commit()
        except Exception, e:
            raise e


class Packet:
    # Converts a packet from a PI to an object to be stored into table
    def __init__(self, n_id, location, node_status):
        self.n_id = n_id
        self.location = location
        self.node_status = node_status


class SensorPacket:
    def __init__(self, transaction_id, value):
        self.transaction_id = transaction_id
        self.value = value


class HistoryPacket:
    def __init__(self, transaction_id, node_id, status, ip_addr, location):
        self.transaction_id = transaction_id
        self.node_id = node_id
        self.node_status = status
        self.node_ip = ip_addr
        self.location = location


class Location:

    def __init__(self, x, y, z):
        self.x_loc = x
        self.y_loc = y
        self.z_loc = z


if __name__ == "__main__":

    # db name, user, host, password
    psgu_utility = Utility("postgres", "postgres", "localhost", "password")

    tst_location = Location(20.0, 26.0, 38.0)

    tst_packet = Packet(12, tst_location, False)

    psgu_utility.ups_into_table(tst_packet)