all: dev-web

# Launch profiles from "./Properties/launchSettings.json"

# Runs the two commands in parallel
# powershell -Command "Start-Process 'dotnet' -ArgumentList 'run' -WorkingDirectory './MotorMount' -NoNewWindow"
dev-desktop:
	powershell -Command "Start-Process 'dotnet' -ArgumentList 'run' -WorkingDirectory './MotorMount'"
	powershell -Command "Start-Process 'dotnet' -ArgumentList 'run' -WorkingDirectory './BlazorWinForms'"

# Runs the default "https" profile in development mode
dev-web:
	cd ./MotorMount/ && dotnet run

build-web:
	cd ./MotorMount/ && dotnet run --configuration Release

dev-web-https:
	cd ./MotorMount/ && dotnet run --launch-profile "https"

dev-web-http:
	cd ./MotorMount/ && dotnet run --launch-profile "http"