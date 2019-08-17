# BenchmarkFloatVsDouble
Puzzling results for benchmark timing!

The benchmark time for Func2Double (x64-release) does not make sense!

```
D:\files\dev\BenchmarkFloatVsDouble\BenchmarkFloatVsDouble>csc /platform:x64 /optimize- /debug+ /debug:full /define:DEBUG;TRACE /out:BenchmarkFloatVsDouble-x64-debug.exe Program.cs

Microsoft (R) Visual C# Compiler version 3.2.0-beta4-19380-04 (5e176ad8)
Copyright (C) Microsoft Corporation. All rights reserved.


D:\files\dev\BenchmarkFloatVsDouble\BenchmarkFloatVsDouble>csc /platform:x64 /optimize+ /debug- /debug:pdbonly /define:TRACE /out:BenchmarkFloatVsDouble-x64-release.exe Program.cs

Microsoft (R) Visual C# Compiler version 3.2.0-beta4-19380-04 (5e176ad8)
Copyright (C) Microsoft Corporation. All rights reserved.


D:\files\dev\BenchmarkFloatVsDouble\BenchmarkFloatVsDouble>csc /platform:x86 /optimize- /debug+ /debug:full /define:DEBUG;TRACE /out:BenchmarkFloatVsDouble-x86-debug.exe Program.cs

Microsoft (R) Visual C# Compiler version 3.2.0-beta4-19380-04 (5e176ad8)
Copyright (C) Microsoft Corporation. All rights reserved.


D:\files\dev\BenchmarkFloatVsDouble\BenchmarkFloatVsDouble>csc /platform:x86 /optimize+ /debug- /debug:pdbonly /define:TRACE /out:BenchmarkFloatVsDouble-x86-release.exe Program.cs

Microsoft (R) Visual C# Compiler version 3.2.0-beta4-19380-04 (5e176ad8)
Copyright (C) Microsoft Corporation. All rights reserved.


D:\files\dev\BenchmarkFloatVsDouble\BenchmarkFloatVsDouble>BenchmarkFloatVsDouble-x64-debug.exe

OSDescription: Microsoft Windows 10.0.16299
OSArchitecture: X64
ProcessArchitecture: X64
FrameworkDescription: .NET Framework 4.7.3416.0

PROCESSOR_ARCHITEW6432:
PROCESSOR_ARCHITECTURE: AMD64
PROCESSOR_IDENTIFIER: Intel64 Family 6 Model 58 Stepping 9, GenuineIntel
NUMBER_OF_PROCESSORS: 8

Is64BitProcess: True
Is64BitOperatingSystem: True

    Func1Double,      Func1Float,     Func2Double,      Func2Float
           1453,            1547,             485,             453
           1437,            1531,             454,             453
           1407,            1500,             453,             453
           1422,            1515,             453,             469
           1406,            1500,             469,             453
           1391,            1500,             453,             469
           1406,            1500,             453,             469
           1422,            1500,             453,             469
           1390,            1500,             469,             453
           1406,            1516,             469,             469
Done


D:\files\dev\BenchmarkFloatVsDouble\BenchmarkFloatVsDouble>BenchmarkFloatVsDouble-x64-release.exe

OSDescription: Microsoft Windows 10.0.16299
OSArchitecture: X64
ProcessArchitecture: X64
FrameworkDescription: .NET Framework 4.7.3416.0

PROCESSOR_ARCHITEW6432:
PROCESSOR_ARCHITECTURE: AMD64
PROCESSOR_IDENTIFIER: Intel64 Family 6 Model 58 Stepping 9, GenuineIntel
NUMBER_OF_PROCESSORS: 8

Is64BitProcess: True
Is64BitOperatingSystem: True

    Func1Double,      Func1Float,     Func2Double,      Func2Float
             31,              31,             375,              32
             31,              15,             375,              32
             31,              31,             391,              31
             31,              16,             375,              31
             31,              16,             375,              31
             32,              31,             375,              15
             32,              31,             375,              16
             31,              31,             375,              16
             31,              31,             375,              16
             16,              31,             375,              32
Done


D:\files\dev\BenchmarkFloatVsDouble\BenchmarkFloatVsDouble>BenchmarkFloatVsDouble-x86-debug.exe

OSDescription: Microsoft Windows 10.0.16299
OSArchitecture: X64
ProcessArchitecture: X86
FrameworkDescription: .NET Framework 4.7.3416.0

PROCESSOR_ARCHITEW6432: AMD64
PROCESSOR_ARCHITECTURE: x86
PROCESSOR_IDENTIFIER: Intel64 Family 6 Model 58 Stepping 9, GenuineIntel
NUMBER_OF_PROCESSORS: 8

Is64BitProcess: False
Is64BitOperatingSystem: True

    Func1Double,      Func1Float,     Func2Double,      Func2Float
           1719,            1672,             484,             469
           1719,            1687,             484,             454
           1718,            1688,             484,             469
           1703,            1688,             484,             453
           1734,            1750,             500,             485
           1750,            1750,             500,             469
           1765,            1735,             500,             468
           1766,            1687,             485,             469
           1703,            1687,             485,             468
           1766,            1719,             484,             500
Done


D:\files\dev\BenchmarkFloatVsDouble\BenchmarkFloatVsDouble>BenchmarkFloatVsDouble-x86-release.exe

OSDescription: Microsoft Windows 10.0.16299
OSArchitecture: X64
ProcessArchitecture: X86
FrameworkDescription: .NET Framework 4.7.3416.0

PROCESSOR_ARCHITEW6432: AMD64
PROCESSOR_ARCHITECTURE: x86
PROCESSOR_IDENTIFIER: Intel64 Family 6 Model 58 Stepping 9, GenuineIntel
NUMBER_OF_PROCESSORS: 8

Is64BitProcess: False
Is64BitOperatingSystem: True

    Func1Double,      Func1Float,     Func2Double,      Func2Float
           1219,            1203,             375,             375
           1219,            1203,             375,             375
           1219,            1203,             375,             375
           1219,            1234,             375,             375
           1219,            1219,             375,             375
           1234,            1219,             375,             375
           1218,            1219,             375,             375
           1219,            1203,             375,             375
           1219,            1219,             375,             375
           1218,            1250,             375,             375
Done


D:\files\dev\BenchmarkFloatVsDouble\BenchmarkFloatVsDouble>ildasm BenchmarkFloatVsDouble-x64-debug.exe /out=BenchmarkFloatVsDouble-x64-debug.exe.il

D:\files\dev\BenchmarkFloatVsDouble\BenchmarkFloatVsDouble>ildasm BenchmarkFloatVsDouble-x64-release.exe /out=BenchmarkFloatVsDouble-x64-release.exe.il

D:\files\dev\BenchmarkFloatVsDouble\BenchmarkFloatVsDouble>ildasm BenchmarkFloatVsDouble-x86-debug.exe /out=BenchmarkFloatVsDouble-x86-debug.exe.il

D:\files\dev\BenchmarkFloatVsDouble\BenchmarkFloatVsDouble>ildasm BenchmarkFloatVsDouble-x86-release.exe /out=BenchmarkFloatVsDouble-x86-release.exe.il
```

![Compare IL - Func2Double vs Func2Float](Compare%20IL%20-%20Func2Double%20vs%20Func2Float.png)
