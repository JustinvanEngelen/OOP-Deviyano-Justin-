from pokemon_data import *


def intro():
    print("**********************pokebattle************************")

def kies_pokemon(starter, bulbasaur, charmander):
    while True:
        pokemon = input("Welke Pokemon wil jij kiezen? " + ', '.join(str(s) for s in pokemon_list) + " ?: ")
        if pokemon.lower in pokemon_list:
            print("Je hebt gekozen voor " +pokemon+ ".")
            return pokemon
        
        else:
            print("Deze Pokemon staat niet in dit Pokedex.")
            continue

def naam(starter, bulbasaur , charmander):
    while True:
        name=input("Welke naam wil jij je " +starter+ " geven? ")
        lengte=len(name)
        if lengte > naam_lengte:
            print("De naam van je " +starter+ " is te lang.")
            continue

        if name == "":	
            print("De naam van je " +starter+ " is  " +starter+ ".")
            name=starter
            return name
        
        else:
            print("De naam van je " +starter+ " is", name)
            return name
        
#def battle(pokemon, tegenstander):
        
