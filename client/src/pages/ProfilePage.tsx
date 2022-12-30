import { Avatar, Box, Grid, Markdown, Text, Tip } from "grommet";
import { ChatOption, Search, User, UserExpert } from "grommet-icons";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { ProfileForm } from "../components/ProfileForm";
import { ProfileInfo } from "../objects/ProfileInfo";
import { profileRepository } from "../repositories/ProfileRepository";

export const ProfilePage = () => {
  const params = useParams();
  const [profile, setProfile] = useState<ProfileInfo>();

  useEffect(() => {
    profileRepository.getProfile(params["*"]).then((data) => {
      setProfile(data);
    });
  }, []);

  return (
    <Box fill align="center" justify="center">
      <Box width="medium" margin={{ horizontal: "large" }}>
        <Box flex direction="row" align="center" justify="between">
          <Avatar margin="medium">
            <User size="large" />
          </Avatar>
          <Box flex direction="column" justify="center">
            <Text size="xlarge">
              <Markdown>{"**" + profile?.loginName + "**"}</Markdown>
            </Text>
            <Markdown>{"" + profile?.role + ""}</Markdown>
          </Box>
          <Grid
            margin="medium"
            columns={{
              count: 3,
              size: "auto",
            }}
            gap="small"
          >
            {profile?.userProfile?.mentorStatus ?? false ? (
              <Tip content="Ментор">
                <UserExpert color="blue" />
              </Tip>
            ) : (
              ""
            )}
            {profile?.userProfile?.searchStatus ?? false ? (
              <Tip content="Ищет собеседника">
                <ChatOption color="green" />
              </Tip>
            ) : (
              ""
            )}
            {profile?.userProfile?.mentorSearchStatus ?? false ? (
              <Tip content="Ищет ментора">
                <Search color="orange" />
              </Tip>
            ) : (
              ""
            )}
          </Grid>
        </Box>
        <Box>
          <Box background="light-1" pad="small" margin="small">
            <Text margin={"xsmall"}>
              <Markdown>{"**О себе:**"}</Markdown>
            </Text>
            <Text margin={{ horizontal: "small" }}>
              <Markdown>{profile?.userProfile?.description ?? "" + ""}</Markdown>
            </Text>
            <Text margin={"xsmall"}>
              <Markdown>{"**Компетенции:**"}</Markdown>
            </Text>
            <Text margin={{ horizontal: "small" }}>
              {profile?.userProfile?.knowledge ?? ""}
            </Text>
            <Text margin={"xsmall"}>
              <Markdown>{"**Интересы:**"}</Markdown>
            </Text>
            <Text margin={{ horizontal: "small" }}>
              {profile?.userProfile?.interests ?? ""}
            </Text>
          </Box>
        </Box>
        {!params["*"] && <ProfileForm />}
      </Box>
    </Box>
  );
};
