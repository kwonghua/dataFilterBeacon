# dataFilterBeacon

C#, using composition to mimic multiple inheritance, reuses dataFilter code

dataFilterBeacon ‘types’ and thus reflect the ‘cross-product’ of both inheritance hierarchies. 
Composite type functionality must be represented, e.g. dataFilterBeacon, dataModBeacon, dataCutBeacon, dataFilterStrobeBeacon, dataFilterQuirkyBeacon, …, etc.

where each beacon object: 
May be on or off May be charged or not Emits a signal, 
if on and charged, 
which reduces its charge Accepts an integer sequence to vary its signal
