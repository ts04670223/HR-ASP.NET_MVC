# 人力資源盤點

## 資料庫設計：
```
1. 為用Windows 驗證。
2. 首先先建立一個hr資料庫。。
3. 建立四個資料表，分別是basicInformation、department、education、experience、supervisor。
4. basicInformation用來存放個人基本資料，包含所屬部門欄位、員工編號欄位、姓名欄位、到職日期欄位、是否為主管欄位、隸屬主管欄位。
5. department用來存放部門欄位。
6. education用來存放學歷，包含學位欄位、學校欄位、畢業科系欄位、basicInformation的id欄位。
7. experience用來存放經歷，包含服務單位欄位、職稱欄位、工作內容欄位、起欄位、迄欄位、basicInformation的id欄位。
8. supervisor用來存放主管，包含主管名稱欄位、所屬部門欄位、職位欄位。
9. department資料表主要用手動新增，以利之後若要更動部門可以快速同步更新。
10. education和experience資料表以basicInformationID欄位與個人資料表id做串接，以利之後若要刪改資料可以連動，同時可以減少多餘資料。
11. supervisor資料表以name與basicInformation個人資料表做串接，以利之後若要刪改資料可以連動，同時可以減少多餘資料。
```
1. 個人基本資料資料表-basicInformation
   - id
   - department
   - staffCode
   - name
   - onDuty
   - position
   - supervisor
2. 部門欄位資料表- department
   - id
   - department
3. 學歷資料表- education
   - id
   - degree
   - school
   - department
   - basicInformationID
4. 經歷資料表- experience
   - id
   - serviceUnit
   - title
   - jobDescription
   - start
   - finish
   - basicInformationID
5. 主管資料表- supervisor
   - id
   - name
   - department
   - title

## 程式開發方式
1. 主要有應用套件DataTables、bootstrap等。
2. 串接資料庫為MS SQL。
3. 使用程式語言主要有C#等。


## 程式功能設計概念
1. 接收個人資料並存入資料庫，同時設計若選擇無主管下拉式選單可選擇職位名稱，若選擇有主管下拉式選單可選擇主管名。
2. 接收學歷資料，可對應個人資料並存入資料庫。
3. 接收工作經驗資料，可對應個人資料並存入資料庫。
4. 個人人員資料列表顯示。

## 畫面設計介紹：
1. 首頁
   - 以表單顯示所有人員，欄位包括:所屬部門欄位、員工編號欄位、姓名欄位、到職日期欄位、職位欄位、直屬主管、操作欄位。
   - 有輸入欄位，輸入欄位名稱可以自動篩選，使表內內容只包含指定的欄位名。
   - 有顯示數量的下拉選單，可決定畫面要呈現資料的數量。
   - 有排序功能點擊表單標題，可以自動篩選表單內容，將同樣名稱的內容歸類再一起，若內容為數字點擊可有大到小排序或有小到大排序。
   - 有編輯按鈕，可編輯個別人員資料，會連動資料庫。
   - 有詳細按鈕，可顯示個別人員全部資料。
   - 有刪除按鈕，可刪除個別人員資料，會一併刪除選擇人的所有資料。
   - 有頁籤和上下頁按鈕，可連動顯示內容。
   - 有新增人員按鈕，可新增主管和一般人員資料。
2. 新增人員畫面
   - 畫面顯示各別需要輸入的輸入框。
   - 同時包含新增按鈕和重置按鈕。
3. 詳細資料畫面
   - 畫面分別顯示不同人員的詳細資料。


