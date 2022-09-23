<?php

namespace Web\models;

use Exception;
use Web\services\iApi_service;

class User
{
    public $id;
    public string $name;
    public string $sur_name = "";
    public int $age;
    private iApi_service $api_service;

    public function __construct($data, iApi_service $service)
    {
        $this->api_service = $service;

        User::validate($data);
        $this->id = $data['id'] ?? null;
        $this->name = $data['name'];
        $this->age = $data['age'];
        $this->surName = $data['surName'];
    }

    public function save_user()
    {
        if (is_null($this->id)) {
            $result = $this->api_service->add_user($this);
            if (!isset($result->statusCode) || $result->statusCode !== 201) {
                throw new Exception('An unnexpected error has ocurred');
            }
        } else {
            $result = $this->api_service->update_user($this, $this->id);
            if (!isset($result->name)) {
                throw new Exception('An unnexpected error has ocurred');
            }
        }
        return true;
    }

    private function validate($data)
    {
        if (empty($data['name'])) {
            throw new Exception('The field name is required');
        }
        if (!$data['age'] > 0) {
            throw new Exception('The field age must be greater than 0');
        }
    }
}
