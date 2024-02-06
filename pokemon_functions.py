from pokemon_data import *

def naam():
    while True:
        name=input("Welke naam wil jij je Charmander geven? Als er geen naam is ingevuld, dan wordt de naam Charmander.")
        if name.isspace() or name == str():
            print("Je hebt een onjuiste naam ingevuld. Probeer het opnieuw.")
            continue

        if name == "":
            print("De naam van je Charmander is Charmander.")
            name=charmander["name"]
            return name

        else:
            print("De naam van je Charmander is "+name+".")
            return name