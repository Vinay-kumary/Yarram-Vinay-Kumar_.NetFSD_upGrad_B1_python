import os
import json
import csv

DATA_DIR = "data"
TICKETS_FILE = os.path.join(DATA_DIR, "tickets.json")
LOGS_FILE = os.path.join(DATA_DIR, "logs.txt")
BACKUP_FILE = os.path.join(DATA_DIR, "backup.csv")
PROBLEMS_FILE = os.path.join(DATA_DIR, "problems.json")


def setup_files():
    os.makedirs(DATA_DIR, exist_ok=True)

    if not os.path.exists(TICKETS_FILE):
        with open(TICKETS_FILE, "w", encoding="utf-8") as f:
            json.dump({"tickets": []}, f, indent=4)

    if not os.path.exists(PROBLEMS_FILE):
        with open(PROBLEMS_FILE, "w", encoding="utf-8") as f:
            json.dump({"problems": []}, f, indent=4)

    if not os.path.exists(LOGS_FILE):
        with open(LOGS_FILE, "w", encoding="utf-8") as f:
            f.write("=== LOGS START ===\n")

    if not os.path.exists(BACKUP_FILE):
        with open(BACKUP_FILE, "w", newline="", encoding="utf-8") as f:
            writer = csv.writer(f)
            writer.writerow(["id", "name", "department", "issue", "category", "priority", "status", "created", "updated"])


def load_tickets():
    setup_files()
    with open(TICKETS_FILE, "r", encoding="utf-8") as f:
        data = json.load(f)

    if isinstance(data, dict):
        return data.get("tickets", [])
    return data


def save_tickets(tickets):
    with open(TICKETS_FILE, "w", encoding="utf-8") as f:
        json.dump({"tickets": tickets}, f, indent=4)

    backup_csv(tickets)


def backup_csv(tickets):
    with open(BACKUP_FILE, "w", newline="", encoding="utf-8") as f:
        writer = csv.writer(f)
        writer.writerow(["id", "name", "department", "issue", "category", "priority", "status", "created", "updated"])
        for t in tickets:
            writer.writerow([
                t.get("id"),
                t.get("name"),
                t.get("department"),
                t.get("issue"),
                t.get("category"),
                t.get("priority"),
                t.get("status"),
                t.get("created"),
                t.get("updated")
            ])