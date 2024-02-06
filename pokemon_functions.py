def naam():
    while True:
        name = input("Welke naam wil jij je Charmander geven? Als er geen naam is ingevuld, dan wordt de naam Charmander: ")
        
        if not name.strip():  # Check for empty input
            name = "Charmander"
            print(f"Je hebt geen naam ingevuld. De naam is nu {name}.")
        elif len(name) > 12:
            print("De ingevoerde naam is te lang. Voer een naam in met maximaal 12 tekens.")
        else:
            print(f"De naam van je Charmander is nu {name}.")
            return name  # Return the entered name if not empty
            break
