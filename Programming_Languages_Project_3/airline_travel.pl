flight_destination('BOS', 'ORD', 6711, 815, 1005).
flight_destination('ORD', 'SFO', 2134, 930, 1345).
flight_destination('SFO', 'LAX', 1176, 1430, 1545).
flight_destination('LAX', 'LGA', 205, 1630, 2210).
flight_destination('LGA', 'ORD', 211, 700, 830).
flight_destination('EWR', 'ORD', 92221, 800, 920).
flight_destination('LGA', 'LAX', 203, 730, 1335).
flight_destination('PHX', 'DFW', 954, 1655, 1800).
flight_destination('LGA', 'BOS', 111, 645, 745).
flight_destination('BOS', 'EWR', 222, 750, 845).

% Question 1
% Define a rule to find the destination of a flight from a given airport
destination(From, To) :-
    flight_destination(From, To, _, _, _).

% Question 2
% Define a rule to check if there's a flight to a given destination
flight_to_destination(To) :-
    flight_destination(_, To, _, _, _).

% Question 3
% Define a rule to find the arrival time of flights from a given airport
arrival_time_from(From, ArrivalTime) :-
    flight_destination(From, _, _, _, ArrivalTime).

% Built-in find all function for creating an array of all arrival locations
% findall(ArrivalTime, arrival_time_from('LGA', ArrivalTime), ArrivalTimes).

% Question 4
% Rule to check if a flight from Airport1 to Airport2 departs after a flight from Airport3 to Airport1 lands
flight_departure_after_arrival(Airport1, Airport2, Airport3) :-
    flight_destination(Airport3, Airport1, _, _, ArrivalTime1),
    flight_destination(Airport1, Airport2, _, DepartureTime2, _),
    DepartureTime2 > ArrivalTime1.

% Question 5
% Define a rule to find the arrival times of flights landing at a given airport
arrival_times_to(Airport, ArrivalTime) :-
    flight_destination(_, Airport, _, _, ArrivalTime).

% Question 6
% Base case: Direct flight from From to To.
route(From, To, Visited, [From-To], _) :-
    flight_destination(From, To, _, _, _),
    \+ member(To, Visited).

% Recursive case: Flight from From to an intermediate Stop,
% then from Stop to To, considering flights not yet visited.
route(From, To, Visited, [From-Stop | Rest], LastArrivalTime) :-
    flight_destination(From, Stop, _, _, ArrivalTime),
    flight_destination(Stop, NextStop, _, DepartureTime, _),
    ArrivalTime >= LastArrivalTime, 
    DepartureTime > ArrivalTime,
    \+ member(Stop, Visited),
    route(Stop, To, [Stop | Visited], Rest, ArrivalTime).

% Public interface to find routes, starts with an empty list of visited airports.
find_routes(From, To, Routes) :-
    route(From, To, [From], Routes, 0).

% Test cases 
%
% destination('PHX', X).
% flight_to_destination('PHX').
% arrival_time_from('BOS', Time).
% flight_departure_after_arrival('ORD', 'SFO', 'EWR').
% arrival_times_to('ORD', Time).
% find_routes('LGA', 'LAX', Routes).
% 


