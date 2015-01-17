
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
    def Ups_into_table(self, packets):

        try:
            for packet in packets:
                self.cur.execute(
                    "SELECT update_db(%s,%s,%s,(%s,%s,%s));",
                    (packet.n_id, packet.node_type,packet.node_status,packet.location.x_loc,packet.location.y_loc,packet.location.z_loc)
                )
                self.conn.commit()
        except Exception, e:
            print e


class Packet:
    # Converts a packet from a PI to an object to be stored into table
    def __init__(self, n_id, location, node_type, node_status):
        self.n_id = n_id
        self.location = location
        self.node_type = node_type
        self.node_status = node_status


class Location:

    def __init__(self, x_loc, y_loc, z_loc):
        self.x_loc = x_loc
        self.y_loc = y_loc
        self.z_loc = z_loc


if __name__ == "__main__":

    psgu_utility = Utility("postgres","postgres","localhost","password")

    tst_location = Location(20.0, 26.0, 38.0)

    tst_packet = Packet(12, tst_location,1, False)
    tst_packets = []
    tst_packets.append(tst_packet)

    psgu_utility.Ups_into_table(tst_packets)