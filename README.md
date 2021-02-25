# dataFilterBeacon

C#, using composition to mimic multiple inheritance, reuses dataFilter code

dataFilterBeacon ‘types’ and thus reflect the ‘cross-product’ of both inheritance hierarchies. 
Composite type functionality must be represented, e.g. dataFilterBeacon, dataModBeacon, dataCutBeacon, dataFilterStrobeBeacon, dataFilterQuirkyBeacon, …, etc.

.................................................................................................................................................................................

BEACON:
where each beacon object: 
May be on or off May be charged or not Emits a signal, 
if on and charged, 
which reduces its charge Accepts an integer sequence to vary its signal

QUIRKYBEACON:
// quirkyBeacon is-a beacon that emits signals from which a discernible pattern is not evident. 
// quirkyBeacons can be turned off and on only a limited number of times(variable across type but stable for an individual object). 

STROBEBEACON:
// strobeBeacon is-a beacon that alternates its signal response, 
// oscillating between negative and positive (or high and low). 
// strobeBeacons cannot be recharged. 

.................................................................................................................................................................................

DATAFILTER:
dataFilters: where each object encapsulates a prime number p and provides the functionality to filter and to scramble an integer sequence:
filter() -- obj is of type dataFilter -- returns a subset of an encapsulated integer sequence, as follows
returns ‘p’ if the internal sequence is null
Otherwise, returns,
when in ‘large’ mode, all integers larger than p
when in ‘small’ mode, all integers smaller than p

DATACUT: 
// dataCut is an dataFilter and operates as one such that it will encapsulate a non-negative prime number with a int array sequence
// dataCut is intially set to 'Large' mode
// if the given number is not a prime number, it will be updated to the nearest greatest prime number 
// if given a negative number it will be updated to a default value

DATAMOD: 
// dataMod is an dataFilter and operates as one such that it will encapsulate a non-negative prime number with a int array sequence
// dataMod is intially set to 'Large' mode
// if the given number is not a prime number, it will be updated to the nearest greatest prime number 
// if given a negative number it will be updated to a default value


.................................................................................................................................................................................

DATAFILTERBEACON:
// dataFilterBeacon has a beacon and dataFilter encapsulated
// user can expect this object to interact like a dataFilter and beacon object combined
// a dataFilterBeacon can be on or off, charged or not, and in 'small' or 'large' mode
// 
// dataFilterBeacon can be constructed with a int sequence array and some number n used for dataFilter
// both the encapuslated beacon and dataFilter will contain the same sequence
// and in that case base beacon and base dataFilter will be used
// if either a dataFilter or beacon type is passed in as null, dataFilterBeacon will never be deactivated
// supports passing in of IDataFilter and IBeacon childs as they can stand in for beacon and dataFilter



scramble(seq) -- obj is of type dataFilter
updates the encapsulated sequence with seq, if not null
returns a reordered integer sequence, as follows
When in ‘large’ mode, views a sequence of n integers as n/2 pairs;
