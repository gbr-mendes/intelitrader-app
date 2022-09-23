<?php

namespace Web\services;

include('iUserServices.php');

use Web\models\User;

class UserServices implements iUserServices
{
    private iApi_service $api_service;
    public function __construct(iApi_service $api_service)
    {
        $this->api_service = $api_service;
    }

    public function get_users(): array
    {
        $data = json_decode($this->api_service->call_api('GET', false));
        return $data;
    }

    public function get_user_by_id($user_id): User
    {
        $data = json_decode($this->api_service->call_api('GET', false, $user_id), true);
        return new User($data);
    }

    public function add_user(User $user): bool
    {
        $data = json_encode($user);
        $response = $this->api_service->call_api('POST', $data);
        $decoded_resp = json_decode($response);
        if (isset($decoded_resp->statusCode)) {
            return $decoded_resp->statusCode === 201 ? true : false;
        }
        return false;
    }
    public function update_user(User $user): bool
    {
        $data = json_encode($user);
        $response = $this->api_service->call_api('PUT', $data);
        $decoded = json_decode($response);
        return isset($decoded->name) ? true : false;
    }
    public function delete_user($user_id): bool
    {
        $response = $this->api_service->call_api('DELETE', false, $user_id);
        $decoded_resp = json_decode($response);
        if (isset($decoded_resp->statusCode)) {
            return $decoded_resp->statusCode === 200 ? true : false;
        }
        return false;
    }
}
