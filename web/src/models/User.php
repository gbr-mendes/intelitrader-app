<?php

namespace Web\models;

use Web\exceptions\ValidationException;

class User
{
    public $id;
    public string $name;
    public string $surName = "";
    public int $age;

    public function __construct($data)
    {
        $this->id = $data['id'] ?? null;
        $this->name = $data['name'];
        $this->surName = $data['surName'];
        $this->age = (int)$data['age'];
        $this->validate();
    }

    public function validate()
    {
        if (empty($this->name)) {
            throw new ValidationException('The field name is required');
        }
        if (!$this->age > 0) {
            throw new ValidationException('The field age must be greater than 0');
        }
    }
}
