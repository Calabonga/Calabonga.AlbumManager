# Фотоальбом (Photo Album)

## Описание

Фотоальбом позволяет получить папку с фотографиями для удобного просмотра с разбиением на месяцы или сортировкой по наименованию файлов. Просмотр фотографий можно настроить удобным образом.

Реализация задачи в виде библиотеки (nuget-пакет, например, `Calabonga.PhotoAlbum`), который можно использовать на разных платформах (дополнительные пакеты, например, `Calabonga.PhotoAlbum.AspNetCore`). Изначальная реализация на платформе `ASP.NET Core`.

Фотоальбом управляется централизовано через `AlbumManager`, работа которого конфигурируется на базе подключенных модулей (процессоров). Процессор – своего рода обработчик данных на определенном этапе работы.

Опционально можно подключить к фотоальбому следующие процессоры (обработчики) фотографий и папок:

* `AlbumCreator` - инициализирует данные (изображения) для работы `AlbumManager`. Возможны разные варианты инициализации:
  * `FolderAlbumCreator`
  * `FolderTreeAlbumCreator`
  * `RemoteStorageAlbumCreator`
* Представление для отображение изображений. Возможно подключение одного из списка:
  * `DefaultViewer`
  * `ThumbnailViewer`
  * `CalendarViewer`
  * `AlphabetViewer`
  * `CarouselViewer`
* `MetadataReader` - определяет где и как, и вообще нужно ли получать метаданные к фотографиям. Возможные следующие варианты:
  * `DefaultMetadataReader`
  * `TextFileMetadataReader`
  * `DatabaseMetadataReader`
* `AlbumEditor` - Редактор изображений в фотоальбоме. По умолчанию, редактора альбома не подключено, возможности редактировать нет.
* `AlbumUploader` - загрузчик изображений, который позволяет дополнить фотоальбом новыми фотографиями.

## Список функциональности (TODO)

### Менеджер файлов

`AlbumManager` - главный объект для запуска процессов: поиск фото, сортировки, фильтрации и т.д. и т.п. `AlbumManager` умеет настраивать представления для выдачи картинок

### Генератор альбомов `AlbumCreator`

* `FolderAlbumCreator` - генератор альбома по умолчанию. Находит в папке изображения, которые преобразуются в альбом для просмотра.
* `FolderTreeAlbumCreator` - генератор альбома для вложенных папок с изображениями. Находит в папках изображения, которые преобразуются в альбом для просмотра.
* `RemoteStorageAlbumCreator` - обращается к удаленному хранилищу изображений для генерации альбома для просмотра.

### Представление для просмотра

* `DefaultViewer` - просмотр всех изображений в папке одним списком, включая вложенные папки всех уровней.
* `ThumbnailViewer` - просмотр всех изображений в папке одним списком, включая вложенные папки всех уровней.
* `CalendarViewer` - просмотр всех изображений в папке одним списком, сгруппированных по месяцам и года дат их создания.
* `AlphabetViewer` - просмотр всех изображений в папке одним списком, сгруппированных по первым буквам названий файлов.
* `CarouselViewer` - просмотр случайного количества изображений в папке, выбранных на основе указанных параметров.

### Метаданные для изображений

`MetadataReader` - ViewModel c метаданными. Наличие текстового файла с именем файла загружается как метаданные: "наименование","описание", "метки" и т.д. и т.п.

Примеры конфигураций MetadataReader:

* `DefaultMetadataReader`
* `TextFileMetadataReader`
* `DatabaseMetadataReader`

### Редактор изображений

`AlbumEditor` - редактор изображений. В редакторе изображений можно создать/изменить метаданные изображений, а также можно удалить выбранные файлы вместе с их метаданными.

### Загрузчик изображений

`AlbumUploader` - загрузка изображений. Загрузчик позволяет загрузить изображения и "разложить" их в соответствии с настройками `AlbumManager`, например, с размещением в соответствующие папки.

# Видео о создании

1. [Фотоальбом на C# (часть 1)](https://boosty.to/calabonga/posts/74dbba15-6e6d-4fbf-b480-171883e5b9e8)
2. [Фотоальбом на C# (часть 2)](https://boosty.to/calabonga/posts/bdc392a3-1a21-44e5-b6ba-5b897a83673c)




