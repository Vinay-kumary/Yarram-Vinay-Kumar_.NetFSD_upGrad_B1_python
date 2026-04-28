from datetime import datetime, timedelta
import re

from utils import load_tickets, save_tickets
from logger import info, warning, critical


class Ticket:
    priority_map = {
        "Server Down": "P1",
        "Internet Down": "P2",
        "Laptop Slow": "P3",
        "Password Reset": "P4"
    }

    sla_map = {
        "P1": 1,
        "P2": 4,
        "P3": 8,
        "P4": 24
    }

    def __init__(self, name, department, issue, category, ticket_type):
        self.id = self.generate_id()
        self.name = name
        self.department = department
        self.issue = issue
        self.category = category
        self.priority = self.priority_map.get(category, "P4")
        self.status = "Open"
        self.created = datetime.now().strftime("%Y-%m-%d %H:%M:%S")
        self.updated = self.created
        self.ticket_type = ticket_type

    @staticmethod
    def generate_id():
        tickets = load_tickets()
        max_num = 1000

        for t in tickets:
            match = re.search(r"TCK(\d+)", t.get("id", ""))
            if match:
                num = int(match.group(1))
                if num > max_num:
                    max_num = num

        return f"TCK{max_num + 1}"

    def to_dict(self):
        return {
            "id": self.id,
            "name": self.name,
            "department": self.department,
            "issue": self.issue,
            "category": self.category,
            "priority": self.priority,
            "status": self.status,
            "created": self.created,
            "updated": self.updated,
            "ticket_type": self.ticket_type
        }


class IncidentTicket(Ticket):
    def __init__(self, name, department, issue, category):
        super().__init__(name, department, issue, category, "Incident")


class ServiceRequest(Ticket):
    def __init__(self, name, department, issue, category):
        super().__init__(name, department, issue, category, "Service Request")


class TicketManager:
    def __init__(self):
        self.tickets = load_tickets()

    def save(self):
        save_tickets(self.tickets)

    def create_ticket(self, ticket):
        self.tickets.append(ticket.to_dict())
        self.save()
        info(f"Ticket created: {ticket.id}")
        print(f"\nTicket Created Successfully: {ticket.id}")

    def view(self):
        if not self.tickets:
            print("\nNo tickets found.")
            return

        for t in self.tickets:
            print("\n" + "-" * 45)
            print(f"Ticket ID   : {t['id']}")
            print(f"Name        : {t['name']}")
            print(f"Department  : {t['department']}")
            print(f"Issue       : {t['issue']}")
            print(f"Category    : {t['category']}")
            print(f"Priority    : {t['priority']}")
            print(f"Status      : {t['status']}")
            print(f"Created     : {t['created']}")
            print(f"Updated     : {t['updated']}")
            print(f"Type        : {t['ticket_type']}")

    def search(self, ticket_id):
        for t in self.tickets:
            if t["id"] == ticket_id:
                return t
        return None

    def update(self, ticket_id, status):
        ticket = self.search(ticket_id)

        if ticket is None:
            print("\nTicket not found.")
            warning(f"Invalid ticket ID: {ticket_id}")
            return

        ticket["status"] = status
        ticket["updated"] = datetime.now().strftime("%Y-%m-%d %H:%M:%S")
        self.save()
        info(f"Ticket updated: {ticket_id} -> {status}")
        print("\nTicket Updated Successfully.")

    def close(self, ticket_id):
        self.update(ticket_id, "Closed")
        info(f"Ticket closed: {ticket_id}")

    def delete(self, ticket_id):
        ticket = self.search(ticket_id)

        if ticket is None:
            print("\nTicket not found.")
            return

        self.tickets.remove(ticket)
        self.save()
        warning(f"Ticket deleted: {ticket_id}")
        print("\nTicket Deleted Successfully.")

    def sla_check(self):
        now = datetime.now()
        found = False

        for t in self.tickets:
            if t["status"] != "Closed":
                created = datetime.strptime(t["created"], "%Y-%m-%d %H:%M:%S")
                elapsed = now - created
                allowed = self.sla_map.get(t["priority"], 24)

                if elapsed > timedelta(hours=allowed):
                    print(f"SLA Breach: {t['id']}")
                    critical(f"SLA breach: {t['id']}")
                    found = True

        if not found:
            print("\nNo SLA breach currently.")