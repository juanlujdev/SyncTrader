# SyncTrader

## Objetivo

La aplicación permitirá que un usuario máster ejecute operaciones en un broker en línea, y estas sean replicadas en las cuentas de los suscriptores de manera automática o previa aprobación manual.

## Plataforma

Aplicación móvil disponible para **Android** e **iOS**.

## Funcionamiento General

1. El usuario máster realiza una operación en el broker.
2. Si el subcriptor tiene desactivada la opcion automática, recibirá una notificación en su dispositivo móvil con la opción de **aceptar o rechazar** la operación y podrá editar el importe de inversión.
3. Si el suscriptor tiene activada la opción de ejecución automática, la operación se realiza directamente.
4. Se puede configurar recibir una notificación vía **SMS, email o WhatsApp** confirmando la ejecución de la operación.
5. Las operaciones se ejecutan en base a una **proporción del capital disponible** de cada suscriptor.
6. Se registrará un **historial** de todas las operaciones ejecutadas.
7. Cada usuario podrá ver las acciones hechas e historiales de beneficios/pérdidas globales o por acciones.
8. Para cada acción se llevará una **gráfica** sobre su evolución en el mercado (puede ser un enlace externo).

## Base de Datos (Estructura Inicial)

### User

| Campo            | Descripción |
|-----------------|-------------|
| `UserId`        | Identificador único del usuario. |
| `Name`          | Nombre del usuario. |
| `Surname`       | Apellido del usuario. |
| `Email`         | Correo electrónico. |
| `PhoneNumber`   | Número de teléfono. |
| `RegistrationDate` | Fecha de registro. |
| `ActuallyUser`  | Estado del usuario (activo/inactivo). |
| `UnsubscriptionDate` | Fecha de baja, si aplica. |
| `Admin`         | Indica si el usuario es administrador. |
| `Amount`        | Cantidad de dinero a invertir. |
| `Password`      | Contraseña de acceso. |
| `BrokerId`      | Broker asociado. |
| `AutomaticAction` | Indica si el usuario elige la inversión automática. |
| `UserMaster`    | Usuario máster que ejecuta las acciones. |

### Action

| Campo          | Descripción |
|---------------|-------------|
| `ActionId`    | Identificador de la acción. |
| `UserId`      | Usuario asociado a la acción. |
| `ActionDate`  | Fecha de ejecución. |
| `CompanyName` | Nombre de la compañía involucrada. |
| `CompanyId`   | Identificador de la compañía. |
| `Amount`      | Cantidad de dinero invertido o vendido. |
| `Percentage`  | Porcentaje invertido o vendido. |
| `StatusId`    | Estado de la acción (efectuada o no). |
| `AutomaticChoice` | Indica si la acción fue manual o automática. |
| `ActionTypeId` | Tipo de acción (Comprar = 2, Vender = 1). |
| `OrderTime`   | Precio al cual se ejecutará la orden (si aplica). |

### Broker

| Campo      | Descripción |
|-----------|-------------|
| `BrokerId` | Identificador del broker. |
| `Name`     | Nombre del broker. |
| `ApiBroker` | API del broker. |
| `Token`    | Token de autenticación. |
| `UserId`   | Usuario asociado. |

### LoggingAction (Registro de Logs)

| Campo            | Descripción |
|-----------------|-------------|
| `LoggingActionId` | Identificador del log. |
| `UserId`        | Usuario asociado. |
| `ActionId`      | Acción registrada. |
| `Amount`        | Cantidad de dinero invertido. |
| `Percentage`    | Porcentaje invertido. |
| `ErrorAction`   | Descripción de errores (si los hubo). |

### ActionType

| Campo           | Descripción |
|---------------|-------------|
| `ActionTypeId` | Identificador del tipo de acción. |
| `TypeName`     | Nombre de la acción ("Comprar", "Vender"). |
| `TypeNameBroker` | Nombre en la app del broker. |
| `TypeBrokerId` | ID de la acción en el broker. |

### StatusAction

| Campo           | Descripción |
|---------------|-------------|
| `StatusId`     | Identificador del estado. |
| `StatusActionName` | Mensaje descriptivo del estado. |

## Modo de Monetización

- La primera versión será gratuita como prueba.
- Se evaluará un modelo de suscripción en versiones futuras.
- Se añadirá integración con **inteligencia artificial (IA)**.
