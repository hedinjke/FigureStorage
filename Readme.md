﻿#### Приложение для хранения фигур
Для того, чтобы добавить фигуру через API необходимо в post запросе предоставить объект с указанием типа фигуры и ее основных свойств. 
Не валидные фигуры небудут добавленые в базу данных.

Пример запроса на добавление окружности:
```json  
POST /figure body:
{
  "type": "rectangle",
  "radius": 10
}
```

Пример запроса на добавление треугольника:
```json  
POST /figure body:
{
  "type": "triangle",
  "sideA": 15,
  "sideB": 13,
  "sideC": 18,
}
```


Запрос GET по id вернёт соответствующую фигуру с указанием типа:
```json  
GET /figure/{id} 
```
```json  
response rectangle:
{
  "type": "Rectangle",
  "radius": 10
}
```
```json  
response triangle:
{
  "type": "Triangle",
  "sideA": 15,
  "sideB": 13,
  "sideC": 18,
}
```

Для generic-биндинга в контроллер реализован DerivedToBaseTypeJsonConverter, работающий вместе
с NewtonsoftJson. При необходимости добавление других иерархий классов необходимо добавить новые конвертер.
Все классы-наследники Figure будут автоматически биндиться в класс Figure в контроллере при необходимости.

Для автоматической настройки маппинга классов-наследников реализован метод MapDtoWithDerived<TType, TTypeDTO>().

### Допущения

- Все фигуры хранятся в библиотеке FigureStorage.Models и наследуются от базового класса FigureStorage.Models.Figure.
- Все DTO фигур хранятся в библиотеке FigureStorage.DTO, наследуются об базового класса FigureStorage.DTO.FigureDTO.
Названия типов DTO повторяют названия своих моделей с постфиксом "DTO" (Figure -> FigureDTO, Rectangle -> RectangleDTO).
Это необходимо для автоматической настройки AutoMapper'а.
(см. FigureStorage.API.Mapper.FigureProfile и FigureStorage.API.Mapper.MapperProfileExtensions)
- Новые фигуры необходимо наследовать от базового класса FigureStorage.Models.Figure и переопределять
свойства Type, IsValid, Area.
- Свойства Type, IsValid, Area должны быть открыты только для чтения.
- Свойства, которые являются исходными данными для создания фигуры, должны быть открытыми на запись и чтение.
- У всех фигур должен быть открытый публичный конструктор (для json-конвертера).
- Контроллер добавит в БД только валидные фигуры.


### Добавление нового типа фигур

- добавить новый класс, наследующий от FigureStorage.Models.Figure `public class NewFigure : Figure {}`
- переопределить свойства Type, IsValid, Area, добавить свойства новой фигуры.
- добавить в RepositoryContext соответствующий `DbSet<NewFigure> NewFigures`
- добавить миграцию: `dotnet ef migrations add AddedNewFigure`
- добавить DTO для новой фигуры: `public class NewFigureDTO : FigureDTO {}`
- добавить Unit-тесты для нового типа фигур.
