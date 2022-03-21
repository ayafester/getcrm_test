# getcrm_test
Входные данные: 
•	Всего – 48 часов
•	Сон – 16 часов
•	Оценка важности – от 1 до 20
•	Количество времени – от 1 часа до 12 ч.
•	Время на дорогу, перекус учитывается в общих затратах.
•	Посещения не совмещаются (например, встреча с друзьями и прогулка в музее)
Алгоритм:
1.	Считаем количество времени нам данное (double all_time)
2.	Создаем структуру данных Place с содержанием (название, кол-во времени, оценка, важность часа)
3.	Считать все данные с таблицы автоматически в список исходных данных. (List data) 
4.	Считаем важность часа в каждой позиции (делить важность на время) и заполняем поле важности часа в списке
5.	Сортируем по убыванию важности часа
6.	Складываем кол-во времени каждой позиции в отсортированном списке, пока время не достигнет 32х часов
7.	Запрашиваем список и выводим