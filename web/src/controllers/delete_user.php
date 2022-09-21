<?php
include('../services/Api_service.php');
$api_service = new Api_service('http://192.168.42.210:8000/api/Users');

if (isset($_GET['user_id'])) {
    try {
        $response = $api_service->delete_user($_GET['user_id']);
        $alert_class = 'alert-success';
        if (isset($response->statusCode) && $response->statusCode === 200) {
            $alert_message = $response->message;
            header("Location: ../index.php?page=users_list&message=${alert_message}&alert_class=${alert_class}");
        }
    } catch (Exception $e) {
        $alert_message = $e->getMessage();
        $alert_class = 'alert-danger';
    }
}
