@description('Location for all resources')
param location string = resourceGroup().location

@description('Name of the App Service plan')
param appServicePlanName string = 'webapp-plan'

@description('Name of the Web App')
param webAppName string

@description('SKU of the App Service plan')
param sku string = 'F1'

resource appServicePlan 'Microsoft.Web/serverfarms@2022-09-01' = {
  name: appServicePlanName
  location: location
  sku: {
    name: sku
    capacity: 1
    tier: 'Free'
  }
  kind: 'linux'
  properties: {
    reserved: true
  }
}

resource webApp 'Microsoft.Web/sites@2022-09-01' = {
  name: webAppName
  location: location
  kind: 'app,linux'
  properties: {
    serverFarmId: appServicePlan.id
    siteConfig: {
      linuxFxVersion: 'NODE|18-lts'
    }
    httpsOnly: true
  }
}
