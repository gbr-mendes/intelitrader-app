<?php
include('./services/ApiService.php');
$api_service = new ApiService('http://192.168.42.210:8000/api/Users');
?>
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!--Font awesome-->
    <script src="https://kit.fontawesome.com/6c6f460c80.js" crossorigin="anonymous"></script>
    <!--Bootstrap CSS-->
    <link rel="stylesheet" href="./assets/bootstrap/css/bootstrap.min.css">
    <!--Styles-->
    <link rel="stylesheet" href="./assets/styles/styles.css">
    <title>User Registration</title>
</head>

<body>
    <main>
        <nav class="navbar navbar-expand-lg navbar-light p-3" id="navbar">
            <div class="container-fluid">
                <a class="navbar-brand" href="./index.php">
                    <i class="fa-solid fa-user-plus"></i>
                </a>
                <div>
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                            <li class="nav-item">
                                <a class="nav-link active" aria-current="page" href="?page=users_list">Users</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link active" aria-current="page" href="?page=add_update_user">Add User</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </nav>