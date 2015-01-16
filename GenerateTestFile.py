import random as r
import os, os.path

def make_tst_file(cases, num_agents, lo_bound):
    # cases = number of total packets
    # num_agents = how many nodes
    # lo_bound = Tuple (Float -> lowest bound of location, Float -> highest bound of location)
    agents = []
    for x in range(0,num_agents):
        # node Types determined here, randomly assign a node type to the agent
        rand = r.random()
        type = 1 if rand > 0.5 else 0
        agents.append((str(x), type))
    low_bound = lo_bound[0]
    high_bound = lo_bound[-1]
    width = high_bound - low_bound
    to_prints = []
    for x in range(0, cases):
        # location x,y,z are all in the range specified in lo_bound
        x_loc = low_bound + width * r.random()
        y_loc = low_bound + width * r.random()
        z_loc = low_bound + width * r.random()
        # Node state will be generated on a 70/30 scale. 70% of the time it is active, otherwise idle
        rand = r.random()
        state = True if rand > 0.7 else False
        # Cycle through the agents
        agent = agents[x % num_agents]
        to_print = str(agent[0]) + "," + "(" + str(x_loc) + "," + str(y_loc) + "," + str(z_loc) + ")," + str(agent[-1]) + "," + str(state)
        to_prints.append(to_print)

    if not os.path.exists('./tests'):
        os.makedirs('./tests')

    num_files = len([name for name in os.listdir('./tests') if os.path.isfile(name)])
    path = './tests/test' + str(num_files + 1) + '.txt'
    case_file = open(path, 'w')
    for to_print in to_prints:
        case_file.write("%s\r\n" % to_print)

# Generate the test file
if __name__ == "__main__":
    # (<Node ID>), (<Location>), (<Node Type>), (<Node State>)
    # Node ID = String
    # Location = Tuple (Float x, Float y, Float z)
    # Node Type = Integer, 0 = Sensor, 1 = Robot
    # Node State = Bool, True = Active, False = Idle
    make_tst_file(30, 10, (-100.0,100.0))