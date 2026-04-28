# Smart IT Service Desk & System Monitoring Automation using Python

## Project Overview
This is an offline Python-based IT support automation system for handling:
- Incident Management
- Service Request Management
- Problem Management
- Change Request Tracking
- SLA Monitoring
- System Health Monitoring
- Report Generation

## Features
- Raise support tickets
- Auto-generate Ticket ID
- Auto-assign priority
- Search, update, close, delete tickets
- SLA breach tracking
- Escalation alerts
- CPU, RAM, Disk monitoring using psutil
- Auto-ticket generation when threshold exceeds
- Data storage in JSON
- Logging in text file
- Backup in CSV
- Problem Record creation if same issue occurs 5 times
- Daily and monthly reports

## Installation
```bash
pip install psutil


▶️ STEP 1: Run program
python main.py

👉 Screen shows:

===== SMART IT SERVICE DESK =====
1.Create Ticket
2.View Tickets
3.Search Ticket
4.Update Status
5.Close Ticket
6.Delete Ticket
7.SLA Alerts
8.System Health
9.Monitoring
10.Daily Report
11.Monthly Report
0.Exit
Choice:

🎤 SAY:

First, I run the application.
It shows a menu-driven interface.

▶️ STEP 2: Create Ticket

👉 Type:

1

👉 Enter details:

Name: Vinay
Dept: IT
Issue: Laptop slow
Category: 3

🎤 SAY:

Here I am creating a ticket.
The system automatically assigns priority based on issue type.

▶️ STEP 3: View Ticket

👉 Type:

2

👉 Output:

ticket_id: TCK1001
employee_name: Vinay
issue_description: Laptop slow
priority: P3
status: Open

🎤 SAY:

Here we can view all tickets with details like ID, issue, priority, and status.

▶️ STEP 4: Search Ticket

👉 Type:

3

👉 Enter:

TCK1001

🎤 SAY:

We can search a ticket using ticket ID.

▶️ STEP 5: Update Status

👉 Type:

4

👉 Enter:

TCK1001
In Progress

🎤 SAY:

Here I update the ticket status.
Tickets move through stages like Open, In Progress, and Closed.

▶️ STEP 6: Close Ticket

👉 Type:

5

👉 Enter:

TCK1001

🎤 SAY:

This option is used to close the ticket after issue resolution.

▶️ STEP 7: System Health

👉 Type:

8

👉 Output:

CPU: 18%
RAM: 70%
Disk: 95%

🎤 SAY:

This module monitors system health like CPU, RAM, and disk usage using Python.

▶️ STEP 8: Report

👉 Type:

10

👉 Output:

Total: 1

🎤 SAY:

This is the daily report showing total tickets.

👉 Then:

11

🎤 SAY:

This shows trends like most common issue.

▶️ STEP 9: Exit

👉 Type:

0

🎤 SAY:

Finally, user can exit the system.

🔁 SIMPLE FLOW (REMEMBER)
Run → Menu → Input → Output → Menu → Input → Exit