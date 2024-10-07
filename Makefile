all: dev

dev: dev-web

web: dev-web

desktop: dev-desktop

# Launch profiles from "./Properties/launchSettings.json"
# Runs the two commands in parallel
# powershell -Command "Start-Process 'dotnet' -ArgumentList 'run' -WorkingDirectory './PCMount' -NoNewWindow"
dev-desktop:
	@powershell -Command "Start-Process 'dotnet' -ArgumentList 'run' -WorkingDirectory './PCMount'"
	@powershell -Command "Start-Process 'dotnet' -ArgumentList 'run' -WorkingDirectory './BlazorWinForms'"

# Runs the default "https" profile in development mode
# cd ./PCMount/ && dotnet run
dev-web:
	@cd ./PCMount/ && dotnet watch run

dev-web-https:
	@cd ./PCMount/ && dotnet run --launch-profile "https"

dev-web-http:
	@cd ./PCMount/ && dotnet run --launch-profile "http"

build: build-web

build-web:
	@cd ./PCMount/ && dotnet run --configuration Release

db: build-db

dev-db:
	@cd ./PCMount/ && dotnet ef database update

rand=%RANDOM%
build-db:
	@cd ./PCMount/ && dotnet ef migrations add $(rand) && dotnet ef database update

relatorio: relatorio_build

relatorio_build:
	@echo "Compilando relatorio..."
	@cd Relatorio && typst compile main.typ

relatorio_watch:
	@echo "Assistindo alterações no relatorio..."
	@cd Relatorio && typst watch main.typ

relatorio_clean:
	@rm -rf Relatorio/main.typ