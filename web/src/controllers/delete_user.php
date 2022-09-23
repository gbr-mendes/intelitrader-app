<?php

use Web\services\Api_service;
use Web\services\UserServices;

include('../services/Api_service.php');
include('../services/UserServices.php');
$api_service = new Api_service('http://192.168.42.210:8000/api/Users');
$user_services = new UserServices($api_service);

if (isset($_GET['user_id'])) {
    try {
        $deleted = $user_services->delete_user($_GET['user_id']);
        if ($deleted) {
            $alert_class = 'alert-success';
            $alert_message = 'User deleted successfuly';
        } else {
            $alert_class = 'alert-danger';
            $alert_message = 'An unnexpected error has ocurred';
        }
    } catch (Exception $e) {
        $alert_message = $e->getMessage();
        $alert_class = 'alert-danger';
    }
    header("Location: ../index.php?page=users_list&message=${alert_message}&alert_class=${alert_class}");
}
