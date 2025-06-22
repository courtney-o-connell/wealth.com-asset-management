This project is designed to retrieve and manage a group of assets efficiently. 

## Installation Instructions

1. **Clone the repository:**
    ```sh
    git clone https://github.com/courtney-o-connell/wealth.com-asset-management
    cd AssetManagementApi
    ```

2. **Copy configuration:**
    Copy the values from `appsettings.Development.json` into your `appsettings.json` file to configure the application for your environment.

3. **Run the application:**
    1. Ensure the launch.json file is configured to run the application.

4. **Comments / Explainations**
    1. The asset-management-db-creation.js file was the script I used to create the mongoDb. A next step I would take is to add an index for the column 'balanceAsOf' in order to improve the search efficiency when querying the database with a given date.
    2. I did not include all the json properities in my current implementation, however it would be beneficial to have more of the asset information returned for debugging and feature enhancement purposes.
    3. This API can be enhanced to include a variety of CRUD endpoints relating to asset management including creating a new asset, updating and asset, etc.
    4. Next steps would be to add unit testing for the command handler and service that I created.

