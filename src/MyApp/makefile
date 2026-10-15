# Makefile для MyMobileApp
# Использование:
#   make build    — собрать Android-проект
#   make run      — собрать и запустить на эмуляторе/устройстве
#   make clean    — удалить bin/obj
#   make rebuild  — clean + build

# Путь к Android-проекту
#ANDROID_PROJECT = ~/MyMobileApp.Android/MyMobileApp.Android.csproj

# Основной проект (используется в clean)
#MAIN_PROJECT = MyMobileApp/MyMobileApp.csproj

.PHONY: build run clean rebuild

# Сборка Android-проекта
build:
	dotnet build

# Сборка и запуск на подключённом устройстве или эмуляторе
run:
	dotnet run

# Очистка всех артефактов сборки
clean:
	@echo "Cleaned."

# Полная пересборка: clean + build
rebuild: adb uninstall com.companyname.mymobileapp
	dotnet build
	dotnet run
