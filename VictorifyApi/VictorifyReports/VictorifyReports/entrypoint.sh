#!/bin/bash

# Dodanie zadania cron do crontab
echo "0 * * * * /usr/bin/dotnet /app/VictorifyReports.dll >> /var/log/cron.log 2>&1" > /etc/cron.d/victorifyreports

# Ustawienie odpowiednich uprawnień do pliku crontab
chmod 0644 /etc/cron.d/victorifyreports


# Upewnij się, że katalog dla PID istnieje
mkdir -p /var/run

# Usuń potencjalny plik blokady PID
if [ -f /var/run/crond.pid ]; then
    rm -f /var/run/crond.pid
fi

# Uruchom cron jako root
service crontab start

# Zapewnij, że kontener pozostanie aktywny
tail -f /var/log/cron.log