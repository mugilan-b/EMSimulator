# EMSimulator
 Simulating Electrodynamics of point charges

You can configure:

# density,range,dim,k,numparts,upperlim,q,ls,acon,mode
  
Density - Density of the points where you calculate field
Values - float, positive, bounded by computational power.

Range - The range (farthest distance along X axis) till where you calculate field
Values - float, positive, bounded by computational power.

dim - Dimensions considered.
Values - 1: Consider only X axis. 2: Consider a grid of 2d points. Rest: Consider only X and Y axes.

numparts - number of charges. Values - Odd integers.

upperlim - Upper limit of Field vector lengths.
Values - Positive float

q - strength of each charge
Values - Float

ls - speed of light.
Values - Positive float

acon - Set constant arrow size (not recommended)
Values - 0 to disable, other integers to enable

mode - Set modes of charge movement:
Values - 0: sinusoidal, 1: circular (recommended with one charge), 2: sinusoidal packet, other integer: no movement.


# How to run:
1) Extract
2) Open v0.0.3/EMSimulator_Data
3) Open set.ini
4) Write the values comma separated, in that order, no spaces or newlines anywhere. A default is provided.
5) Launch EMSimulator.exe

Hold the left mouse button and you can look up/down. Initially it will push you a bit so look around to recenter.
W/A/S/D to move around.
If simulation is slow consider reducing load

# Changelog:
v0.0.3 - First github commit

v0.0.4 - Added different modes of movement, added 'acon' convar.

v0.0.5 - Corrected acceleration vector from a to aperp.
 