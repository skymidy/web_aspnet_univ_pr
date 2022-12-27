import { Box, Button, Form, FormField, TextInput } from "grommet";
import { useState } from "react";
import { Hide, View } from "grommet-icons";

const RegistrationForm = (props: any) => {
  const [value, setValue] = useState({ login: "", password: "" });
  const [reveal, setReveal] = useState(false);

  return (
    <Box fill="horizontal" align="center" justify="center">
      <Box width="medium" margin={{ horizontal: "large" }}>
        <Form
          value={value}
          onChange={(nextValue) => setValue(nextValue)}
          onSubmit={({ value: nextValue }) => console.log(nextValue)}
        >
          <FormField label="Login" name="login" required>
            <TextInput aria-label="login" name="login" type="text" />
          </FormField>
          <FormField label="Password" name="password" required>
            <Box direction="row">
              <TextInput
                focusIndicator={false}
                plain
                aria-label="password"
                name="password"
                type={reveal ? "text" : "password"}
              />
              <Button
                icon={reveal ? <View size="medium" /> : <Hide size="medium" />}
                onClick={() => setReveal(!reveal)}
              />
            </Box>
          </FormField>

          <Box direction="column" margin={{ top: "medium" }}>
            <Button fill type="submit" label="Sign up" primary />
          </Box>
        </Form>
      </Box>
    </Box>
  );
};

export { RegistrationForm };
