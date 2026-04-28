from datetime import datetime
from utils import LOGS_FILE, setup_files


def log(level, message):
    setup_files()
    with open(LOGS_FILE, "a", encoding="utf-8") as f:
        f.write(f"[{datetime.now().strftime('%Y-%m-%d %H:%M:%S')}] [{level}] {message}\n")


def info(message):
    log("INFO", message)


def warning(message):
    log("WARNING", message)


def error(message):
    log("ERROR", message)


def critical(message):
    log("CRITICAL", message)