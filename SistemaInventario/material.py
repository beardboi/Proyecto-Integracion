class Material():
    def __init__(self, id, nombre, descripcion, unidad_medida, cantidad, precio):
        self.id = id
        self.nombre = nombre
        self.descripcion = descripcion
        self.unidad_medida = unidad_medida
        self.cantidad = cantidad
        self.precio = precio

    def actualizar_stock(self, cantidad_usada):
        if cantidad_usada > 0:
            self.cantidad = self.cantidad - cantidad_usada
