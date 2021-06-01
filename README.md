# The Roller Coaster Problem

According to [Little Book Of Semaphores](https://greenteapress.com/semaphores/LittleBookOfSemaphores.pdf):

Suppose there are `n` passenger threads, and a car thread. The passengers repeatedly wait to take rides
in the car, which can hold `C` passengers, where `C < n`. The car can go around the tracks only
when it is full.

Here are some additional details:
* passengers should invoke `Board` and `Unboard`.
* the car should invoke `Load`, `Run` and `Unload`;
* passengers cannot board until the car has invoked `Load`;
* the car cannot depart until `C` passengers have boarded;
* passengers cannot unboard until the car has invoked `Unload`.

Puzzle: Write code for the passengers and car that enforces these constraints.
