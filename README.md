# Project-stock-quote-alert(ConsoleQuote)

ConsoleQuote is a program that monitors ibovespa stocks and triggers alerts to the user.

## Configure the smtp server

in the file configSmtp.json change the server data

### Example

 "email": "designationemail@designation.com",
 "port": 587,
 "host" = "smtp.gmail.com",
 "emailcredencial": "some@some.com",
 "password": "password"

## Usage

in the directory

C:\Users\joaomaues\Documents\Projetos\inoa\Project-stock-quote\ConsoleStock\bin\Debug>

run the command: ConsoleQuote <STOCK> <MAX> <MIN>

STOCK = Stock you want track
MAX = the max value of stock
MIN = the min value of stock

### Example

PETR4 24,45 20,34