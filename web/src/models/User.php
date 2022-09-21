<?php
class User
{
    public $id;
    public string $name;
    public string $surName = "";
    public int $age;
    private $api_service = null;

    public function __construct($data, $service)
    {
        $this->api_service = $service;

        User::validate($data);
        $this->id = $data['id'] ?? null;
        $this->name = $data['name'];
        $this->age = $data['age'];
        $this->surName = $data['surName'];
        return User::saveUser($this);
    }

    private function saveUser($user)
    {
        if (is_null($user->id)) {
            $result = $this->api_service->add_user($user);
            if (!isset($result->statusCode) || $result->statusCode !== 201) {
                throw new Exception('An unnexpected error has ocurred');
            }
        } else {
            $result = $this->api_service->update_user($user, $user->id);
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
