
import psycopg2 as psy

class PostGreSqlUtility:

    conn = None
    cur = None

    def __init__(self, db_name, user, host, password):
        try:
            conn = psy.connect("dbname="+db_name, "user="+user,"host="+host,"password="+password)
            cur = conn.cursor()
        except Exception, e:
            print e
    # Insert
    def ins_into_table(table_name, Packets):
        try:
            cur.execute("INSERT INTO test_table (node_id,node_type,node_status,location)")
        except:

class Packet:
    # Converts a packet from a PI to an object to be stored into table
    def __init__(self, id, location, node_type, node_status):
        self.id = id
        self.location = location
        self.node_type = node_type
        self.node_status = node_status

class Location:

    def __init__(self, x_loc, y_loc, z_loc):
        self.x_loc = x_loc
        self.y_loc = y_loc
        self.z_loc = z_loc