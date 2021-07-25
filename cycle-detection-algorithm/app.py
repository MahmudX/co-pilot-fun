# Create a method implements Floyd's Tortoise and Hare algorithm
# to find the shortest path between two nodes in a graph.

def floyd_tortoise_and_hare(graph, start, end):
    tortoise = start
    hare = end
    path = []
    path_length = 0
    while tortoise != hare:
        path.append(tortoise)
        path_length += graph[tortoise][hare]
        tortoise = next_node(graph, tortoise)
        hare = next_node(graph, hare)
    path.append(hare)
    path_length += graph[hare][tortoise]
    return path, path_length

def next_node(graph, current):
    next_nodes = graph[current]
    return next_nodes.keys()[next_nodes.values().index(min(next_nodes.values()))]
