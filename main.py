from utils import setup_files
from tickets import TicketManager, IncidentTicket, ServiceRequest
from monitor import Monitor
from reports import ReportGenerator


def show_menu():
    print("\n===== ITIL SERVICE DESK =====")
    print("1. Create Incident")
    print("2. Create Service Request")
    print("3. View Tickets")
    print("4. Search Ticket")
    print("5. Update Status")
    print("6. Close Ticket")
    print("7. Delete Ticket")
    print("8. SLA Check")
    print("9. System Health")
    print("10. Auto Monitor")
    print("11. Daily Report")
    print("12. Monthly Report")
    print("0. Exit")


def select_category():
    print("\nSelect Category")
    print("1. Server Down")
    print("2. Internet Down")
    print("3. Laptop Slow")
    print("4. Password Reset")

    choice = input("Category: ").strip()

    category_map = {
        "1": "Server Down",
        "2": "Internet Down",
        "3": "Laptop Slow",
        "4": "Password Reset"
    }

    return category_map.get(choice)


def create_ticket_flow(ticket_manager, ticket_type):
    name = input("Name: ").strip()
    department = input("Department: ").strip()
    issue = input("Issue: ").strip()

    if name == "" or department == "" or issue == "":
        print("\nEmpty values are not allowed.")
        return

    category = select_category()

    if category is None:
        print("\nInvalid category.")
        return

    if ticket_type == "incident":
        ticket = IncidentTicket(name, department, issue, category)
    else:
        ticket = ServiceRequest(name, department, issue, category)

    ticket_manager.create_ticket(ticket)


def main():
    setup_files()

    ticket_manager = TicketManager()
    monitor = Monitor(ticket_manager)
    report = ReportGenerator(ticket_manager)

    while True:
        show_menu()
        choice = input("Choice: ").strip()

        if choice == "1":
            create_ticket_flow(ticket_manager, "incident")

        elif choice == "2":
            create_ticket_flow(ticket_manager, "service")

        elif choice == "3":
            ticket_manager.view()

        elif choice == "4":
            ticket_id = input("Ticket ID: ").strip()
            ticket = ticket_manager.search(ticket_id)
            if ticket:
                print("\nTicket Found:")
                print(ticket)
            else:
                print("\nTicket not found.")

        elif choice == "5":
            ticket_id = input("Ticket ID: ").strip()
            status = input("Status: ").strip()
            ticket_manager.update(ticket_id, status)

        elif choice == "6":
            ticket_id = input("Ticket ID: ").strip()
            ticket_manager.close(ticket_id)

        elif choice == "7":
            ticket_id = input("Ticket ID: ").strip()
            ticket_manager.delete(ticket_id)

        elif choice == "8":
            ticket_manager.sla_check()

        elif choice == "9":
            monitor.show()

        elif choice == "10":
            monitor.auto()

        elif choice == "11":
            report.daily()

        elif choice == "12":
            report.monthly()

        elif choice == "0":
            print("\nThank you. Exiting.")
            break

        else:
            print("\nInvalid choice.")


if __name__ == "__main__":
    main()