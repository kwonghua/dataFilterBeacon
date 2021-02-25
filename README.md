# dataFilterBeacon

C#, using composition to mimic multiple inheritance, reuses dataFilter code

dataFilterBeacon ‘types’ and thus reflect the ‘cross-product’ of both inheritance hierarchies. 
Composite type functionality must be represented, e.g. dataFilterBeacon, dataModBeacon, dataCutBeacon, dataFilterStrobeBeacon, dataFilterQuirkyBeacon, …, etc.

where each beacon object: 
May be on or off May be charged or not Emits a signal, 
if on and charged, 
which reduces its charge Accepts an integer sequence to vary its signal


dataFilters: where each object encapsulates a prime number p and provides the functionality to filter and to scramble an integer sequence:
filter() -- obj is of type dataFilter -- returns a subset of an encapsulated integer sequence, as follows
returns ‘p’ if the internal sequence is null
Otherwise, returns,
when in ‘large’ mode, all integers larger than p
when in ‘small’ mode, all integers smaller than p

scramble(seq) -- obj is of type dataFilter
updates the encapsulated sequence with seq, if not null
returns a reordered integer sequence, as follows
When in ‘large’ mode, views a sequence of n integers as n/2 pairs;
