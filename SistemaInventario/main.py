from os import system
from material import Material
import sqlite3

def iniciar_db():
    conn = sqlite3.connect('database.db')

    create_table_material = """CREATE TABLE IF NOT EXISTS material (
       id INTEGER PRIMARY KEY,
       nombre TEXT NOT NULL,
       descripcion TEXT NOT NULL,
       precio INTEGER NOT NULL,
       unidadMedida TEXT NOT NULL,
       cantidad INTEGER NOT NULL)"""

    create_table_movimiento = """CREATE TABLE IF NOT EXISTS movimiento (
        id INTEGER PRIMARY KEY,
        fecha DATETIME NOT NULL,
        materialID INTEGER NOT NULL,
        cantiad INTEGER NOT NULL,
        FOREIGN KEY (materialID) REFERENCES material (id))"""

    cursor = conn.cursor()
    cursor.execute(create_table_material)   
    cursor.execute(create_table_movimiento)   

iniciar_db()

def obtener_materiales():
    conn = sqlite3.connect('database.db')
    query = 'SELECT * FROM material'
    cursor = conn.cursor()
    cursor.execute(query)
    
    rows = cursor.fetchall()

    i = 1
    for row in rows:
        print(f'{i} - {row}')
        i+=1

def obtener_movimientos():
    conn = sqlite3.connect('database.db')
    query = 'SELECT * FROM movimiento'
    cursor = conn.cursor()
    cursor.execute(query)
    
    rows = cursor.fetchall()

    i = 1
    for row in rows:
        print(f'{i} - {row}')
        i+=1

def mostrar_menu():
    menu = """
    1) Imprimir lista de materiales
    2) Movimiento por material 
    3) Salir
    """

    system('cls')
    print(menu)
    res = input("Ingrese una opcion\n")
    if res == "1":
        system('cls')
        print(obtener_materiales())
        salir = input('1) Salir\n')
        if salir == "1":
            mostrar_menu()

    if res == "2":
        system('cls')
        print(obtener_movimientos())
        salir = input('1) Salir\n')
        if salir == "1":
            mostrar_menu()

    if res == "3":
        system('cls')
        print("Cerrando programa...")

mostrar_menu()
