all: dev

dev: dev-web

# Launch profiles from "./Properties/launchSettings.json"
# Runs the two commands in parallel
# powershell -Command "Start-Process 'dotnet' -ArgumentList 'run' -WorkingDirectory './MotorMount' -NoNewWindow"
dev-desktop:
	powershell -Command "Start-Process 'dotnet' -ArgumentList 'run' -WorkingDirectory './MotorMount'"
	powershell -Command "Start-Process 'dotnet' -ArgumentList 'run' -WorkingDirectory './BlazorWinForms'"

# Runs the default "https" profile in development mode
# cd ./MotorMount/ && dotnet run
dev-web:
	cd ./MotorMount/ && dotnet watch run

build: build-web

build-web:
	cd ./MotorMount/ && dotnet run --configuration Release

dev-web-https:
	cd ./MotorMount/ && dotnet run --launch-profile "https"

dev-web-http:
	cd ./MotorMount/ && dotnet run --launch-profile "http"

relatorio: relatorio_build

relatorio_build:
	@echo "Compilando relatorio..."
	@cd Relatorio && typst compile main.typ

relatorio_watch:
	@echo "Assistindo alterações no relatorio..."
	@cd Relatorio && typst watch main.typ

relatorio_clean:
	@rm -rf Relatorio/main.typ