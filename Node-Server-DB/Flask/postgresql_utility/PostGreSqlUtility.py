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


class Packet:
    # Converts a packet from a PI to an object to be stored into table
    def __init__(self, n_id, location, node_status):
        self.n_id = n_id
        self.location = location
        self.node_status = node_status


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