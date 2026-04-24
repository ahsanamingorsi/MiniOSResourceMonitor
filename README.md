# Mini Operating System Resource Monitor

![C#](https://img.shields.io/badge/Language-C%23-blue)
![.NET](https://img.shields.io/badge/Framework-.NET-purple)
![WinForms](https://img.shields.io/badge/UI-WinForms-green)
![Status](https://img.shields.io/badge/Project-Academic-orange)

<p align="center">

<h2>🚀 Download Latest Release</h2>

<a href="https://github.com/USERNAME/REPO/releases/latest/download/MiniOSResourceMonitor.exe">
  <img src="https://img.shields.io/badge/Download-Windows%20EXE-1f6feb?style=for-the-badge&logo=github&logoColor=white" />
</a>

</p>

A desktop simulation application built with **C# WinForms** that demonstrates how an operating system manages system resources such as **CPU, memory, and I/O devices**.

This project simulates key operating system concepts including **process lifecycle, resource allocation, and system performance monitoring**.

---

# Overview

The **Mini Operating System Resource Monitor** is an educational simulator designed to help students understand how operating systems manage limited system resources.

Instead of accessing real hardware, the system creates a **simulated environment** where processes request CPU, memory, and I/O resources. The simulator applies operating system rules to allocate resources and control process state transitions.

This allows users to visually observe how operating systems manage processes and system performance.

---

# Features

- System resource configuration
- Process creation and management
- Process lifecycle simulation
- Resource allocation monitoring
- Performance metrics calculation
- Interactive desktop interface
- Process state visualization

---

# Technologies Used

| Technology | Purpose |
|---|---|
| C# | Application logic |
| .NET | Framework |
| WinForms | Desktop UI |
| Visual Studio | Development environment |

---

# System Modules

## 1 System Configuration

Users first define the total system resources.

Example configuration:

- Total CPU Units: 100  
- Total Memory: 8192 MB  
- Total I/O Units: 4  

These values represent the maximum resources available in the simulated system.

---

## 2 Process Management

Users create processes and define their attributes.

Process attributes:

- Process ID
- CPU Requirement (%)
- Memory Requirement (MB)
- I/O Requirement (Units)

All values are entered manually by the user.

---

## 3 Process State Lifecycle

The simulator follows the standard operating system process lifecycle.

```
New
Ready
Running
Waiting
Terminated
```

State transitions:

```
New -> Ready
Ready -> Running
Running -> Waiting
Waiting -> Ready
Running -> Terminated
```

---

## 4 Resource Allocation

Resources are allocated dynamically according to availability.

Rules used in the simulator:

- CPU is allocated when a process enters the Running state
- Memory must be available before execution
- I/O resources are assigned when required
- If resources are unavailable, the process remains in the waiting state

---

# Performance Metrics

The simulator calculates several system performance metrics.

### CPU Utilization

```
CPU Utilization = (Used CPU / Total CPU) * 100
```

### Memory Usage

```
Total allocated memory
```

### Throughput

```
Completed processes / Simulation time
```

### Waiting Time

```
Total time spent in Ready and Waiting states
```

These metrics help analyze overall system performance.

---

# User Interface

The application interface includes:

- System Configuration Panel
- Process Creation Form
- Process Table
- Resource Usage Display
- Simulation Control Buttons

The UI allows users to monitor resource allocation and process state changes during the simulation.

---

# Project Structure

```
Mini-OS-Resource-Monitor
│
├── SourceCode
│
├── Documentation
│
├── Images
│
└── README.md
```

---

# Limitations

This project is a simplified operating system simulator.

Limitations include:

- No real hardware interaction
- Simulation time is abstracted
- Single CPU core assumption
- Maximum 20 processes supported
- No advanced scheduling algorithms

These limitations keep the system focused on core operating system concepts.

---

# Educational Purpose

This simulator is developed for academic use to help students understand:

- Process lifecycle management
- Resource allocation
- Operating system performance metrics
- Basic system architecture

---

# Authors

Mubashar Yasin  
Muneeb Mazhar  
Ahsan Amin  

Department of Computer Science  
University of Kotli  
Session 2023-2027

---

# License

This project is developed for **educational and academic purposes only**.
