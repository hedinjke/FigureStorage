#### Приложение для хранения фигур
Для того, чтобы добавить фигуру через API необходимо в post запросе предоставить объект с указанием типа фигуры и ее основных свойств. 
Не валидные фигуры небудут добавленые в базу данных.

Пример запроса на добавление окружности:
```json  
POST /figure body:
{
  "type": "circle",
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
response circle:
{
  "type": "Circle",
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
с NewtonsoftJson. При необходимости добавление других иерархий классов (не наследующих от Figure) необходимо добавить соответствующий конвертер (см. ConfigureServices).
Все классы-наследники Figure будут автоматически биндиться в класс Figure в контроллере при необходимости.

Для автоматической настройки маппинга классов-наследников реализован метод MapDtoWithDerived<TType, TTypeDTO>().

### Допущения

- Для хранения фигур в базе данных выбранна модель `TablePerHierarchy`, 
поэтому все классы фигур должны быть декорированы атрибутом `[Table("FigureDbTableName")]`
- Все фигуры хранятся в библиотеке FigureStorage.Models и наследуются от базового класса FigureStorage.Models.Figure.
- Все DTO фигур хранятся в библиотеке FigureStorage.DTO, наследуются об базового класса FigureStorage.DTO.FigureDTO.
Названия типов DTO повторяют названия своих моделей с постфиксом "DTO" (Figure -> FigureDTO, Circle -> CircleDTO).
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
- новый класс обязательно необходимо декорировать атрибутом `[Table("NewFigure")]` для корректной работы `TablePerHierarchy`
- добавить в RepositoryContext соответствующий `DbSet<NewFigure> NewFigures`
- добавить миграцию: `dotnet ef migrations add AddedNewFigure`
- добавить DTO для новой фигуры: `public class NewFigureDTO : FigureDTO {}`
- добавить Unit-тесты для нового типа фигур.

Простейший случай добавления фигуры (но без соответствующих Unit-test'ов) показан [в последнем коммите в ветке new-figure-branch.](https://github.com/hedinjke/FigureStorage/commit/33a5ca63e04c53ea89949ca35cb80707853b79fa)
