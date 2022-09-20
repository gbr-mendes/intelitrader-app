<?php
class AddUpdateUserDto
{
    public string $name;
    public string $surName = "";
    public int $age;

    public function __construct($name, $surName, $age)
    {
        if (empty($name)) {
            throw new Exception('The field name is required');
        } else {
            $this->name = $name;
        }
        if (!$age > 0) {
            throw new Exception('The field age must be greater than 0');
        } else {
            $this->age = $age;
        }
        $this->surName = $surName;
    }
}
