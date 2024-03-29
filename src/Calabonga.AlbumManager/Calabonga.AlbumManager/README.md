﻿# AlbumeManager (Фотоальбом на C#)


## Версии

### 1.0.0-beta.1 от 2024-01-27
* Первый релиз.

## Описание

Фотоальбом позволяет получить папку с фотографиями для удобного просмотра с разбиением на месяцы или сортировкой по наименованию файлов. Просмотр фотографий можно настроить удобным образом.

Реализация задачи в виде библиотеки (nuget-пакет, `Calabonga.AlbumManager`), который можно использовать на разных платформах. 

Фотоальбом конфигурируется через `AlbumManagerBuilder`, работа которого построена на базе подключенных модулей (процессоров). Процессор – своего рода обработчик данных на определенном этапе работы.

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

# Видео о создании nuget-пакета

1. [Фотоальбом на C# (часть 1)](https://www.calabonga.net/blog/post/photoalbum-csharp-1)
2. [Фотоальбом на C# (часть 2)](https://www.calabonga.net/blog/post/photoalbum-csharp-2)
3. [Фотоальбом на C# (часть 3)](https://www.calabonga.net/blog/post/photoalbum-csharp-3)
4. [Фотоальбом на C# (часть 4)](https://www.calabonga.net/blog/post/photoalbum-csharp-4)
5. [Фотоальбом на C# (часть 5)](https://www.calabonga.net/blog/post/photoalbum-csharp-5)
6. [Фотоальбом на C# (часть 6)](https://www.calabonga.net/blog/post/photoalbum-csharp-6)
7. [Фотоальбом на C# (часть 7)](https://www.calabonga.net/blog/post/photoalbum-csharp-7)
8. [Фотоальбом на C# (часть 8)](https://www.calabonga.net/blog/post/photoalbum-csharp-8)
9. [Фотоальбом на C# (часть 9)](https://www.calabonga.net/blog/post/photoalbum-csharp-9)
10. [Фотоальбом на C# (часть 10)](https://www.calabonga.net/blog/post/photoalbum-csharp-10)
11. [Фотоальбом на C# (часть 11)](https://www.calabonga.net/blog/post/photoalbum-csharp-11)
12. [Фотоальбом на C# (часть 12)](https://www.calabonga.net/blog/post/photoalbum-csharp-12)
13. [Фотоальбом на C# (часть 13)](https://www.calabonga.net/blog/post/photoalbum-csharp-13)
14. [Фотоальбом на C# (часть 14)](https://www.calabonga.net/blog/post/photoalbum-csharp-14)
15. [Фотоальбом на C# (часть 15)](https://www.calabonga.net/blog/post/photoalbum-csharp-15)
16. [Фотоальбом на C# (часть 16)](https://www.calabonga.net/blog/post/photoalbum-csharp-16)
17. [Фотоальбом на C# (часть 17)](https://www.calabonga.net/blog/post/photoalbum-csharp-17)
