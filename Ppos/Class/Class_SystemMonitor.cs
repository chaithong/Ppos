using System;
using System.Diagnostics;

public class SystemMonitor : IDisposable
{
    private readonly PerformanceCounter _cpuCounter;
    private readonly PerformanceCounter _memCounter;
    private readonly PerformanceCounter _diskCounter; // เพิ่มตัวนับสำหรับ Disk
    private readonly double _totalMemoryMb;

    public SystemMonitor()
    {
        // 1. ตัวนับ CPU และ RAM เดิม
        _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        _memCounter = new PerformanceCounter("Memory", "Available MBytes");

        // 2. ตัวนับ Disk Active Time (คำนวณย้อนหลังจาก % Idle Time ของทุกดิสก์รวมกัน)
        // หมายเหตุ: การใช้ 100 - % Idle Time จะได้ค่าที่ตรงและนิ่งใกล้เคียง Task Manager ที่สุด
        _diskCounter = new PerformanceCounter("PhysicalDisk", "% Idle Time", "_Total");

        // 3. หาหน่วยความจำ RAM ทั้งหมด
        var computerInfo = new Microsoft.VisualBasic.Devices.ComputerInfo();
        _totalMemoryMb = computerInfo.TotalPhysicalMemory / (1024.0 * 1024.0);

        // สั่งให้ตัวนับทำงานครั้งแรกทิ้งไว้ก่อน (เพราะค่าแรกมักจะเป็น 0)
        _cpuCounter.NextValue();
        _diskCounter.NextValue();
    }

    /// <summary>
    /// ดึงค่า % CPU ณ ปัจจุบัน
    /// </summary>
    public float GetCpuUsage()
    {
        return _cpuCounter.NextValue();
    }

    /// <summary>
    /// ดึงค่า % RAM ณ ปัจจุบัน
    /// </summary>
    public double GetRamUsagePercentage()
    {
        float availableMemoryMb = _memCounter.NextValue();
        double usedMemoryMb = _totalMemoryMb - availableMemoryMb;
        return (usedMemoryMb / _totalMemoryMb) * 100;
    }

    /// <summary>
    /// ดึงค่า % Disk Active Time ณ ปัจจุบัน (เหมือนใน Task Manager)
    /// </summary>
    public float GetDiskUsagePercentage()
    {
        // ค่า % Idle Time คือเปอร์เซ็นต์ที่ดิสก์ว่างอยู่ 
        // ดังนั้น เอา 100 ตั้ง แล้วลบออกด้วยค่าว่าง จะได้เปอร์เซ็นต์ที่ดิสก์กำลังทำงานจริง
        float idleTime = _diskCounter.NextValue();
        float diskUsage = 100f - idleTime;

        // ดักเงื่อนไขในกรณีที่ดิสก์ทำงานหนักมากจนค่าทะลุ 100 หรือติดลบ (เกิดจากความเร็ว I/O ของสเปกเครื่อง)
        if (diskUsage > 100f) return 100f;
        if (diskUsage < 0f) return 0f;

        return diskUsage;
    }

    public void Dispose()
    {
        _cpuCounter?.Dispose();
        _memCounter?.Dispose();
        _diskCounter?.Dispose(); // คืนทรัพยากรตัวนับดิสก์
    }
}
