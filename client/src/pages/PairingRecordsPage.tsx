import { Box, Grid, Text } from "grommet";
import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { PairRecord } from "../objects/PairRecord";
import { PairsInfo } from "../objects/PairsInfo";
import { parisRepository } from "../repositories/ParisRepository";

export const PairingRecordsPage = (props: any) => {
  const [records, setRecords] = useState<PairsInfo>();

  useEffect(() => {
    parisRepository.getPairsRecords().then((data) => {
      setRecords(data);
    });
  }, []);
  return (
    <Box fill align="center" justify="center">
      <Grid
        margin="medium"
        columns={{
          count: 5,
          size: "auto",
        }}
        gap="small"
      >
        <>
          <Text>{"#"}</Text>
          <Text>{"Собеседник"}</Text>
          <Text>{"Типа"}</Text>
          <Text>{"Рейтинг (от 0 до 10)"}</Text>
          <Text>{"Комментарий"}</Text>
        </>
        {records?.list.map((record: PairRecord, index: number) => (
          <>
            <Text>{index}</Text>
            <Text>
              <Link to={"/profile/" + record.pairedUserId}>
                {record.pairedUserId}
              </Link>
            </Text>
            <Text>{record.type}</Text>
            <Text>{record.rating}</Text>
            <Text>{record.ratingDescription}</Text>
          </>
        ))}
      </Grid>
    </Box>
  );
};
