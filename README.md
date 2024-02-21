# Project Name

This project is for demonstrations purposes only. It consists of a basic 

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)
- [Todo](#todo)

## Installation

This project uses .NET 8 and MSSQL Server 2022.
It can be run on debug mode on Visual Studio Code.

## Usage

Before running the project, the user must create a .env file containing on the main folder the connection string to the database following the format below

DB_CONNECTION_STRING=your_connection_string_here

To check the extract on the customer's wallet the user can check the endpoint api/UserActionsController/UserWalletExtract/{username} passing the email as a username.

The application is also set to send a mock email to each manager every day at 09:00 and runs as a background service.

## Todo

- Implement customer buy/sell financial products actions
- Implement the method to properly fill the email's body.
- Implement authorizations for each endpoint depending on the user role

