import psutil
from tickets import IncidentTicket
from logger import critical, info


class Monitor:
    def __init__(self, ticket_manager):
        self.ticket_manager = ticket_manager

    def show(self):
        cpu = psutil.cpu_percent(interval=1)
        ram = psutil.virtual_memory().percent
        disk_used = psutil.disk_usage("/").percent
        disk_free = 100 - disk_used
        net = psutil.net_io_counters()

        print("\nSYSTEM HEALTH")
        print("-" * 35)
        print(f"CPU Usage       : {cpu}%")
        print(f"RAM Usage       : {ram}%")
        print(f"Disk Used       : {disk_used}%")
        print(f"Disk Free       : {disk_free}%")
        print(f"Network Sent    : {net.bytes_sent} bytes")
        print(f"Network Received: {net.bytes_recv} bytes")

    def auto(self):
        cpu = psutil.cpu_percent(interval=1)
        ram = psutil.virtual_memory().percent
        disk_used = psutil.disk_usage("/").percent
        disk_free = 100 - disk_used

        created = False

        if cpu > 90:
            ticket = IncidentTicket("System Monitor", "IT", "High CPU Usage", "Server Down")
            self.ticket_manager.create_ticket(ticket)
            critical("Auto ticket created for high CPU")
            created = True

        if ram > 95:
            ticket = IncidentTicket("System Monitor", "IT", "High RAM Usage", "Server Down")
            self.ticket_manager.create_ticket(ticket)
            critical("Auto ticket created for high RAM")
            created = True

        if disk_free < 10:
            ticket = IncidentTicket("System Monitor", "IT", "Disk Free Space Low", "Server Down")
            self.ticket_manager.create_ticket(ticket)
            critical("Auto ticket created for disk low")
            created = True

        if not created:
            info("Auto monitoring checked. No issue found.")
            print("\nSystem normal. No auto ticket created.")