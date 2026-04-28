from collections import Counter


class ReportGenerator:
    def __init__(self, ticket_manager):
        self.ticket_manager = ticket_manager

    def daily(self):
        tickets = self.ticket_manager.tickets

        total = len(tickets)
        open_count = sum(1 for t in tickets if t["status"] != "Closed")
        closed_count = sum(1 for t in tickets if t["status"] == "Closed")
        high_count = sum(1 for t in tickets if t["priority"] in ["P1", "P2"])

        print("\nDAILY REPORT")
        print("-" * 35)
        print(f"Total Tickets        : {total}")
        print(f"Open Tickets         : {open_count}")
        print(f"Closed Tickets       : {closed_count}")
        print(f"High Priority Tickets: {high_count}")

    def monthly(self):
        tickets = self.ticket_manager.tickets

        if not tickets:
            print("\nNo tickets available.")
            return

        issue_count = Counter(t["category"] for t in tickets)
        dept_count = Counter(t["department"] for t in tickets)

        print("\nMONTHLY REPORT")
        print("-" * 35)
        print(f"Most Common Issue : {issue_count.most_common(1)[0][0]}")
        print(f"Top Department    : {dept_count.most_common(1)[0][0]}")